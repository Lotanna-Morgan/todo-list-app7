import { Injectable } from '@angular/core';
import { TodoDetail } from './todo-detail.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TodoDetailService {

  constructor(private http: HttpClient) { }

  readonly baseURL = 'https://localhost:44339/api/TodoItemDetail/';

  formData: TodoDetail = new TodoDetail();
  list: TodoDetail[];

  deleteTodoItem(id: number) {
    return this.http.delete(`${this.baseURL}${id}`);
  }

  postTodoItem() {
    return this.http.post(this.baseURL, this.formData);
  }

  refreshList() {
    this.http.get(this.baseURL).toPromise()
    .then(res => this.list = res as TodoDetail[]);
  }
  
  updateTodoItem() {
    return this.http.put(`${this.baseURL}${this.formData.todoItemId}`, this.formData);
  }

  // Mark an item as complete using HTTP PUT/UPDATE
  updateTodoItemCompletionStatus(requestBody: TodoDetail) {
    return this.http.put(`${this.baseURL}${requestBody.todoItemId}`, requestBody);
  }
}
