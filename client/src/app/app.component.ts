import { Component } from '@angular/core';
import { Todo } from './Models/Todo';
import { TodoService } from './todo.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'Todo-List';
  todos;
  content: string;

  constructor(private service: TodoService) {}

  GetTodos() {
    this.service.GetTodos().subscribe((data) => {
      this.todos = data;
      console.log(this.todos);
    });
  }

  PostTodo() {
    let todo = new Todo();
    todo.content = this.content;
    if (todo.content) {
      this.service.PostTodo(todo);
    }
    setTimeout(() => {
      this.GetTodos();
    }, 1000);
  }

  DeleteTodo(id){
    this.service.DeleteTodo(id);
    setTimeout(() => {
      this.GetTodos();
    }, 1000);
  }
  UpdateTodo(id,content){
    let todo = new Todo();
    todo.content = content;
    this.service.UpdateTodo(id,todo);
  }
}
