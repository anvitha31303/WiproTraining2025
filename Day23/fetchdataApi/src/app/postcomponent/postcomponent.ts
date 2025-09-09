import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Dataservice } from '../dataservice';

@Component({
  selector: 'app-posts',
  imports: [CommonModule],
  standalone:true,
  template: `
  <ul>
    <li *ngFor="let post of posts">
         {{post.title}}
    </li>
   </ul>`,
})
export class Postcomponent implements OnInit{
  posts:any[]=[];
  constructor(private DataService: Dataservice) {}
  ngOnInit() {
    this.DataService.getPosts().subscribe((data)=>{
this.posts= data;

});
}

}
