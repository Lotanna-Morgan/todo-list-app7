import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { TodoDetailService } from 'src/app/shared/todo-detail.service';
import {TodoDetail } from 'src/app/shared/todo-detail.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-todo-detail-form',
  templateUrl: './todo-detail-form.component.html',
  styles: [
  ]
})
export class TodoDetailFormComponent implements OnInit {

  constructor(public service: TodoDetailService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
    if(this.service.formData.todoItemId == 0)
      this.insertNewItem(form);
    else
      this.updateExistingItem(form);
  }

  insertNewItem(form: NgForm) {
    this.service.postTodoItem().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success('Item Added Successfully!', 'To-Do Items Listing');
      }, 

      err => {
        console.log(err);
      }
    );
  }

  updateExistingItem(form: NgForm) {
    this.service.updateTodoItem().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('Item Updated Successfully!', 'To-Do Items Listing');
      }, 

      err => {
        console.log(err);
      }
    );
  }

  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new TodoDetail();
  }
}
