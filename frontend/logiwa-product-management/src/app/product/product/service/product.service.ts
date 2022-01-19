import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { GenericService } from 'src/app/service/generic-service';
import { environment } from 'src/environments/environment';
import { ProductDto } from '../model/product-dto.model';
import { SearchProductDto } from '../model/search-product-dto.model';
import { Response } from 'src/app/models/response.model';

@Injectable({
  providedIn: 'root',
})
export class ProductService extends GenericService<ProductDto, number> {
  constructor(protected http: HttpClient) {
    super(http, environment.baseApiUrl + 'product/');
  }

  searchProduct(t: SearchProductDto): Observable<Response> {
    return this._http.post<Response>(this._base + environment.search, t);
  }
}
