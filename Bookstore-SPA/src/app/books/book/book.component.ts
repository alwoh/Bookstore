import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Book } from '../../_models/Book';
import { BookService } from '../../_services/book.service';
import { ToastrService } from 'ngx-toastr';
import { CategoryService } from '../../_services/category.service';

@Component({
  selector: 'app-book',
  standalone: false,
  templateUrl: './book.component.html',
  styleUrl: './book.component.css'
})
export class BookComponent {
  book: Book = { id: 0, name: '', author: '', description: '', value: 0, categoryId: 0, publishDate: new Date() };
  categories: any[] = [];

  constructor(
      private bookService: BookService,
      private categoryService: CategoryService,
      private router: Router,
      private route: ActivatedRoute,
      private toastr: ToastrService
    ) {}

    ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const id = Number(params.get('id'));
      if (id && id > 0) {
        this.bookService.getById(id).subscribe({
          next: (book) => {            
            this.book = book;         
            console.log(this.book.publishDate);   
            const publishDate =  new Date(book.publishDate);      
            this.book.publishDate = this.formatDate(publishDate);
          },
          error: () => {
            this.toastr.error('Failed to load book.');
            this.router.navigate(['/books']);
          }
        });
      }
    });
    this.categoryService.getAll().subscribe({
          next: (categories) => {
            this.categories = categories;
          },
          error: () => {
            this.toastr.error('Failed to categories for book.');
            this.router.navigate(['/books']);
          }
    });
    
  }

  onSubmit(form: NgForm): void {
    if (form.invalid) {
      this.toastr.error('Please fill out the form correctly.');
      return;
    }                           
     this.book.publishDate = this.formatDateForSubmission(this.book.publishDate);    
     if (this.book.id === 0) {
      this.bookService.add(this.book).subscribe({
        next: () => {
          this.toastr.success('Category added successfully!');
          this.router.navigate(['/books']);
        },
        error: () => {
          this.toastr.error('Failed to add book.');
        }
      });
     }
     else {
      this.bookService.update(this.book.id, this.book).subscribe({
        next: () => {
          this.toastr.success('Book updated successfully!');
          this.router.navigate(['/books']);
        },
        error: () => {
          this.toastr.error('Failed to update category.');
        }
      });
     }
    return;    
  }

  onCancel(): void {
    this.router.navigate(['/books']);
  }

  private formatDate(date: Date): Date {
    let year = date.getFullYear();
    let month = String(date.getMonth() + 1);
    let day = String(date.getDate());

    console.log(`${year}-${month}-${day}`);
    return {year : year, month: Number(month), day: Number(day)} as unknown as Date;
  }

  private formatDateForSubmission(date: Object): Date {    
    let year = (date as any).year;
    let month = (date as any).month;
    let day = (date as any).day;
    
    return new Date(`${year}-${month}-${day}`);
  }
}
