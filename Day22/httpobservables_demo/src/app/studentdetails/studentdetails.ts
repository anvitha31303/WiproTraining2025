import { Component, OnInit } from '@angular/core';
import { Studentservice } from '../studentservice';

@Component({
  selector: 'app-studentdetails',
  imports: [],
  templateUrl: './studentdetails.html',
  styleUrl: './studentdetails.css'
})
export class Studentdetails implements OnInit{
/*public students=[
  {"id":300,"name":"shiv","marks":30},
  {"id":301,"name":"yash","marks":70},
  {"id":302,"name":"gita","marks":10},
  {"id":303,"name":"anvi","marks":40},
  {"id":304,"name":"puji","marks":50}
];*/

constructor(private studentService:Studentservice){


}
ngOnInit(){
  this.studentService.getStudents().subscribe(data=>this.students=data);

}
}
