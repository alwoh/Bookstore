import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CategoryService } from '../../_services/category.service';
import { ToastrService } from 'ngx-toastr';
import { ConfirmationDialogService } from '../../_services/confirmation-dialog.service';
import { Subject } from 'rxjs';
import { debounceTime } from 'rxjs/operators';


@Component({
  selector: 'app-category-list',
  standalone: false,
  templateUrl: './category-list.component.html',
  styleUrl: './category-list.component.css'
})
export class CategoryListComponent implements OnInit {
  public categories: any;
  public searchTerm: string;
  public searchValueChanged: Subject<string> = new Subject<string>();

  constructor(private router: Router,
              private service: CategoryService,
              private toastr: ToastrService,
              private confirmationDialogService: ConfirmationDialogService) { }

  ngOnInit(): void {
    this.getCategories();

    this.searchValueChanged.pipe(debounceTime(1000))
      .subscribe(() => {
        this.search();
      });
  }

  private getCategories() {
    this.service.getAll().subscribe({
      next: (categories) => {
      
          this.categories = categories;
       
      },
      error: (err) => {
        console.error('Error loading categories:', err);
        this.toastr.error('Failed to load categories. Please try again later.');
      }
    });
  }

  public addCategory() {
    this.router.navigate(['/category']);
  }

  public editCategory(categoryId: number) {
    this.router.navigate(['/category/' + categoryId]);
  }

  public deleteCategory(categoryId: number) {    
    this.confirmationDialogService.confirm('Do you really want to delete this category?').then(() => {
      this.service.remove(categoryId).subscribe({
        next: () => {
          this.toastr.success('The category has been deleted');
          this.getCategories();
        },
        error: () => {
          this.toastr.error('Failed to delete the category.');
        }
      });
    });
  }

  public searchCategory(searchTerm: string): void {    
    // Implement the logic to filter categories based on the search term
    this.searchValueChanged.next(this.searchTerm);    
  }

  private search() {
    if (this.searchTerm !== '') {
      this.service.search(this.searchTerm).subscribe({
        next: (category) => {
          this.categories = category;
        },
        error: () => {
          this.categories = [];
        }
      });
    } else {
      this.service.getAll().subscribe(categories => this.categories = categories);
    }
  }
}