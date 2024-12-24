import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Course } from './Models/Course';

@Injectable({
  providedIn: 'root'
})
export class CourseService {
  apiUrl:string="http://localhost:5089/api/Course"
  courses:Course[]=[];
    constructor(private http:HttpClient) { }
    GetAllCourses():Observable<any>
    {
      return this.http.get<Course>(this.apiUrl,{observe:'response'})
    }
}
