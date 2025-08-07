import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookService } from '../../_services/book.service';
import { ToastrService } from 'ngx-toastr';
import { ConfirmationDialogService } from '../../_services/confirmation-dialog.service';

@Component({
  selector: 'app-book-list',
  standalone: false,
  templateUrl: './book-list.component.html',
  styleUrl: './book-list.component.css'
})
export class BookListComponent implements OnInit {
  books: any;
  searchTerm: string = '';

  constructor(
    private bookService: BookService,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.loadBooks();
  }

  loadBooks(): void {
    this.bookService.getAll().subscribe({
      next: (books) => {
        this.books = books;
      },
      error: () => {
        this.toastr.error('Failed to load books.');
      }
    });
  }

  searchBook(searchTerm: string): void {
    if (searchTerm.trim() === '') {
      this.loadBooks();
      return;
    }

    this.bookService.search(searchTerm).subscribe({
      next: (books) => {
        this.books = books;
      },
      error: () => {
        this.toastr.error('No books found matching the search term.');
      }
    });
  }

  addBook(): void {
    this.router.navigate(['/book']);
  }

  editBook(bookId: number): void {
    this.router.navigate([`/book/${bookId}`]);
  }

  deleteBook(bookId: number): void {
    if (confirm('Are you sure you want to delete this book?')) {
      this.bookService.remove(bookId).subscribe({
        next: () => {
          this.toastr.success('Book deleted successfully.');
          this.loadBooks();
        },
        error: () => {
          this.toastr.error('Failed to delete the book.');
        }
      });
    }
  }
}
