import { Component } from '@angular/core';
import { CourseService } from '../course.service';
import { Course } from '../Models/Course';

@Component({
  selector: 'app-courselist',
  templateUrl: './courselist.component.html',
  styleUrls: ['./courselist.component.css']
})
export class CourselistComponent {

  courselist:Course[]=[];
  Course: any;
  constructor(private service:CourseService) { }
ngOninit()
{
 this.service.GetAllCourses().subscribe(data=>{
   this.courselist=data.body;
   console.log(this.courselist);
   console.log(data);
   console.log(data as Object);
 })
}
}
