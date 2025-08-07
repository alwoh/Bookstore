import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Category } from '../../_models/Category';
import { CategoryService } from '../../_services/category.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-category',
  standalone: false,
  templateUrl: './category.component.html',
  styleUrl: './category.component.css'
})
export class CategoryComponent implements OnInit {
  category: Category = { id: 0, name: '' };

  constructor(
    private categoryService: CategoryService,
    private router: Router,
    private route: ActivatedRoute,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const id = Number(params.get('id'));
      if (id && id > 0) {
        this.categoryService.getById(id).subscribe({
          next: (category) => {
            this.category = category;
          },
          error: () => {
            this.toastr.error('Failed to load category.');
            this.router.navigate(['/categories']);
          }
        });
      }
    });
  }

  onSubmit(form: NgForm): void {
    if (form.invalid) {
      this.toastr.error('Please fill out the form correctly.');
      return;
    }

    if (this.category.id === 0) {
      this.categoryService.add(this.category).subscribe({
        next: () => {
          this.toastr.success('Category added successfully!');
          this.router.navigate(['/categories']);
        },
        error: () => {
          this.toastr.error('Failed to add category.');
        }
      });
    } else {
      this.categoryService.update(this.category.id, this.category).subscribe({
        next: () => {
          this.toastr.success('Category updated successfully!');
          this.router.navigate(['/categories']);
        },
        error: () => {
          this.toastr.error('Failed to update category.');
        }
      });
    }
  }

  onCancel(): void {
    this.router.navigate(['/categories']);
  }
}
