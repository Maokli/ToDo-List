import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class TodoService {
  url: string = 'https://localhost:5001/tasks';
  headers = new HttpHeaders().set('Content-Type', 'application/json; charset=UTF-8');

  constructor(private http: HttpClient) {}

  GetTodos(){
    return this.http.get(this.url,{
      observe: 'response',
    }).pipe(map((response) => {
      return response.body;
    }));
  }
  PostTodo(todo){
    this.http.post(this.url,todo,{
      headers : this.headers,
      responseType: 'text'
    }).subscribe(response =>{
      console.log(response);
    });
  }
  DeleteTodo(id){
    this.http.delete(this.url +'/'+id)
    .subscribe(response =>{
      console.log(response);
    });
  }
  UpdateTodo(id,todo){
    this.http.put(this.url+'/'+id,todo,{
      headers : this.headers,
      responseType: 'text'
    }).subscribe(response =>{
      console.log(response);
    });
  }
}

