import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import{FormsModule,NgForm} from '@angular/forms';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-root',
  imports: [FormsModule,CommonModule],
  
  templateUrl: './app.html',
  styleUrl: './app.css'
})

export class App {
  protected readonly title = signal('template_driven_forms');

  onSubmit(form:NgForm){
    console.log('Form submitted:',form.value);
  }
}
