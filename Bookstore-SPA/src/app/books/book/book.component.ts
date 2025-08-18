import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Book } from '../../_models/Book';
import { BookService } from '../../_services/book.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-book',
  standalone: false,
  templateUrl: './book.component.html',
  styleUrl: './book.component.css'
})
export class BookComponent {
  book: Book = { id: 0, name: '', author: '', description: '', value: 0, categoryName: '', publishDate: new Date() };

  constructor(
      private boookService: BookService,
      private router: Router,
      private route: ActivatedRoute,
      private toastr: ToastrService
    ) {}

    ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const id = Number(params.get('id'));
      if (id && id > 0) {
        this.boookService.getById(id).subscribe({
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
  }

  onSubmit(form: NgForm): void {
    return;
    
  }
}
