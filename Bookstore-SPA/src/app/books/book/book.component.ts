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
     if (this.book.id === 0) {
      this.bookService.add(this.book).subscribe({
        next: () => {
          this.toastr.success('Category added successfully!');
          this.router.navigate(['/categories']);
        },
        error: () => {
          this.toastr.error('Failed to add book.');
        }
      });
     }
     else {
      return;
     }
    return;    
  }

  onCancel(): void {
    this.router.navigate(['/books']);
  }
}
