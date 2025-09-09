import { Component, signal } from '@angular/core';

import { Studentdetails } from './studentdetails/studentdetails';
import { Studentmarks } from './studentmarks/studentmarks';
import { Studentservice } from './studentservice';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { Pipe,PipeTransform} from '@angular/core';
import{FormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
@Component({
  selector: 'app-root',
  imports: [CommonModule,FormsModule,HttpClientModule,Studentdetails,Studentmarks],
  templateUrl: './app.html',
  styleUrl: './app.css',
  standalone:true,
  providers:[Studentservice],
 
})
export class App {
   title = signal('httpobservables_demo');
}
  @Pipe({
    name:'namePipe'
  })

class NamePipe implements PipeTransform {

transform(value: string, defaultValue: string): string{

if(value != ""){

return value;
} else {

return defaultValue;

}
}}