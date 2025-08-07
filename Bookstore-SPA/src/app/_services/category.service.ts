import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../_models/Category';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  private baseUrl = environment.baseUrl + 'api/Categories';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Category[]> {
    return this.http.get<Category[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<Category> {
    return this.http.get<Category>(`${this.baseUrl}/${id}`);
  }

  add(category: Category): Observable<Category> {
    return this.http.post<Category>(`${this.baseUrl}`, category);
  }

  update(id: number, category: Category): Observable<Category> {
    return this.http.put<Category>(`${this.baseUrl}/${id}`, category);
  }

  remove(id: number): Observable<Category> {
    return this.http.delete<Category>(`${this.baseUrl}/${id}`);
  }

  search(category: string): Observable<Category[]> {
    return this.http.get<Category[]>(`${this.baseUrl}/search/${category}`);
  }
}