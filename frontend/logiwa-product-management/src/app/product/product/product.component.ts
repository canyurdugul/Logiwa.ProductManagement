import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Response } from 'src/app/models/response.model';
import { SearchProductDto } from './model/search-product-dto.model';
import Swal from 'sweetalert2';
import { ProductService } from './service/product.service';
import { ProductDto } from './model/product-dto.model';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
})
export class ProductComponent implements OnInit {
  //#region definitions
  public gridData: any[] = [];
  public categoriesData: any[] = [];
  public selected: any;
  public searchProductDto: SearchProductDto = {
    keyword: '',
  };
  public displayStyle: string = 'none';
  public searchFormDisplayStyle: string = 'none';
  public form: any;
  public searchForm: any;
  dtTrigger: Subject<any> = new Subject<any>();
  //#endregion

  constructor(
    public readonly http: HttpClient,
    private productService: ProductService
  ) {}
  ngOnInit(): void {
    this.getCategories();
    this.getAll();
    this.createSearchForm();
  }

  //#region get data
  public getAll(): void {
    this.productService.getAll().subscribe((response) => {
      this.gridData = response.data;
    });
  }
  public getCategories(): void {
    this.http
      .get<Response>(environment.baseApiUrl + 'category/' + environment.getAll)
      .subscribe((response) => {
        this.categoriesData = response.data;
      });
  }
  //#endregion

  //#region save or update data
  public createProduct(): void {
    this.selected = { id: 0, name: '', minimumStockQuantity: 0 };
    this.createForm();
    this.showForm();
  }
  public editProduct(id: any): void {
    this.productService.get(id).subscribe((response) => {
      this.selected = response.data;
      this.createForm();
      this.showForm();
    });
  }
  public saveOrUpdate(): void {
    this.selected = this.form.value as ProductDto;
    if (this.selected.id > 0) {
      this.productService
        .update(this.selected.id, this.selected)
        .subscribe((response) => {
          if (response.succeeded) {
            Swal.fire('Edited', '', 'success');
            this.getAll();
            this.hideForm();
          }
        });
    } else {
      this.productService.create(this.selected).subscribe((response) => {
        if (response.succeeded) {
          Swal.fire('Created', '', 'success');
          this.getAll();
          this.hideForm();
        }
      });
    }
  }
  public deleteProduct(id: any): void {
    Swal.fire({
      icon: 'question',
      title: 'Delete',
      text: 'Are you sure want to delete this item ?',
      showConfirmButton: true,
      showCancelButton: true,
    }).then((result) => {
      if (result.value) {
        this.productService.delete(id).subscribe((response) => {
          this.getAll();
          Swal.fire('Deleted', '', 'success');
        });
      }
    });
  }
  public searchProduct(): void {
    this.productService
      .searchProduct(this.searchProductDto)
      .subscribe((response) => {
        this.gridData = response.data;
      });
  }
  //#endregion

  //#region  form  operations
  public createForm(): void {
    const { id, title, description, stockQuantity, categoryId } = this.selected;
    this.form = new FormGroup({
      id: new FormControl(id ?? null),
      title: new FormControl(title ?? null, [
        Validators.required,
        Validators.minLength(1),
        Validators.maxLength(200),
      ]),
      description: new FormControl(description ?? null, [
        Validators.minLength(1),
        Validators.maxLength(200),
      ]),
      stockQuantity: new FormControl(stockQuantity ?? 0, [
        Validators.min(0),
        Validators.required,
      ]),
      categoryId: new FormControl(categoryId ?? 0, [Validators.min(1)]),
    });
  }
  public createSearchForm(): void {
    const { keyword, minimumStockQuantity, maximumStockQuantity } =
      this.searchProductDto;
    this.searchForm = new FormControl({
      keyword: new FormControl(keyword ?? null),
      minimumStockQuantity: new FormControl(minimumStockQuantity ?? null),
      maximumStockQuantity: new FormControl(maximumStockQuantity ?? null),
    });
  }
  showForm(): void {
    this.displayStyle = 'block';
  }
  hideForm(): void {
    this.displayStyle = 'none';
  }
  //#endregion
}
