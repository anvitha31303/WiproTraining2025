import { Component } from '@angular/core';
import { NgFor, NgIf } from '@angular/common';
import{FormsModule }from '@angular/forms';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [NgFor, NgIf, FormsModule],
  templateUrl: './app.html',
  styleUrl:'./app.css'
})
export class App{
  students:any[]=[];
  nextId = 1;
  fname = '';
  lname = '';
  city = '';
  marks: number | null = null;
  editIndex: number | null = null;

  saveStudent() {
    if (!this.fname || !this.lname || !this.city || this.marks === null) return;

    if (this.editIndex === null) {
      this.students.push({
        id: this.nextId++,
        fname: this.fname,
        lname: this.lname,
        city: this.city,
        marks: this.marks
      });
    } else {
      this.students[this.editIndex] = {
        id: this.students[this.editIndex].id,
        fname: this.fname,
        lname: this.lname,
        city: this.city,
        marks: this.marks
      };
      this.editIndex = null;
    }
    this.clearForm();
  }

  editStudent(index: number) {
    const s = this.students[index];
    this.fname = s.fname;
    this.lname = s.lname;
    this.city = s.city;
    this.marks = s.marks;
    this.editIndex = index;
  }

  deleteStudent(index: number) {
    this.students.splice(index, 1);
  }

  clearForm() {
    this.fname = '';
    this.lname = '';
    this.city = '';
    this.marks = null;
    this.editIndex = null;
  }
}
