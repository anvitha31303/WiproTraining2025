import { Component,OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-user-form',
  imports: [],
  templateUrl: './user-form.html',
  styleUrl: './user-form.css'
})
export class UserForm  implements OnInit{
  UserForm:FormGroup;

}
