import { AfterViewChecked, Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { TodoDetail } from '../shared/todo-detail.model';
import { TodoDetailService } from '../shared/todo-detail.service';

@Component({
  selector: 'app-todo-details',
  templateUrl: './todo-details.component.html',
  styles: [
  ]
})
export class TodoDetailsComponent implements OnInit {

  constructor(public service: TodoDetailService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  onItemDelete(id: number) {
    if(confirm('Are you sure you want to do delete this item? If yes, click OK.')){
      this.service.deleteTodoItem(id).subscribe(
        res => {
          this.service.refreshList();
          this.toastr.error('Item Deleted Successfully!', 'To-Do Items Listing');
        },

        err => {
          console.log(err)
        }
      );
    }
  }

  onItemStatusChange(selectedItem: TodoDetail) {
    var requestBody = Object.assign({}, selectedItem);
    requestBody.isCompleted = (requestBody.isCompleted) ? false : true;

    this.service.updateTodoItemCompletionStatus(requestBody).subscribe(
      res => {
        this.service.refreshList();
        this.toastr.info('Item Completion Status Successfully Updated!', 'To-Do Items Listing');
      },

      err => {
        console.log(err);
      }
    );
  }

  populateForm(selectedItem: TodoDetail) {
    this.service.formData = Object.assign({}, selectedItem);
  }
}
