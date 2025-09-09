import { Component } from '@angular/core';

@Component({
  selector: 'app-studentmarks',
  imports: [],
  templateUrl: './studentmarks.html',
  styleUrl: './studentmarks.css'
})
export class Studentmarks {
public students=[
  {"id":300,"name":"shiv","marks":30},
  {"id":301,"name":"yash","marks":70},
  {"id":302,"name":"gita","marks":10},
  {"id":303,"name":"anvi","marks":40},
  {"id":304,"name":"puji","marks":50}
];
constructor(){

}
ngOnInit(){

}
}

