import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GenericService } from 'src/app/service/generic-service';
import { environment } from 'src/environments/environment';
import { CategoryDto } from '../model/category-dto.model';

@Injectable({
  providedIn: 'root',
})
export class CategoryService extends GenericService<CategoryDto, number> {
  constructor(protected http: HttpClient) {
    super(http, environment.baseApiUrl + 'category/');
  }
}
