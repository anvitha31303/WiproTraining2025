import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'studentFilter'
})
export class StudentFilterPipe implements PipeTransform {

 transform(students: any[], searchTerm: string): any[] {
    if (!students) return [];
    if (!searchTerm) return students;
    const term = searchTerm.toLowerCase().trim();
    return students.filter(s => s.name.toLowerCase().includes(term));
  }

}
