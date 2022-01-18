import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Response } from 'src/app/models/response.model';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css'],
})
export class CategoryComponent implements OnInit {
  //#region definitions
  private readonly controllerName = 'category/';
  public gridData: any[] = [];
  public selected: any;
  public displayStyle: string = 'none';
  public form: any;
  dtTrigger: Subject<any> = new Subject<any>();
  //#endregion

  constructor(public readonly http: HttpClient, private fb: FormBuilder) {}
  ngOnInit(): void {
    this.getAll();
  }

  //#region  get data
  public getAll(): void {
    this.http
      .get<Response>(
        environment.baseApiUrl + this.controllerName + environment.getAll
      )
      .subscribe((response) => {

        this.gridData = response.data;
      });
  }
  //#endregion

  //#region save or update data
  public createCategory(): void {
    this.selected = { id: 0, name: '', minimumStockQuantity: 0 };
    this.createForm();
    this.showForm();
  }
  public editCategory(id: any): void {
    this.http
      .get<Response>(
        environment.baseApiUrl + this.controllerName + environment.get + id
      )
      .subscribe((response) => {
        this.selected = response.data;
        this.createForm();
        this.showForm();
      });
  }
  public saveOrUpdate(): void {
    this.selected = this.form.value;
    if (this.selected.id > 0) {
      this.http
        .put<Response>(
          environment.baseApiUrl +
            this.controllerName +
            environment.update +
            this.selected.id,
          this.selected
        )
        .subscribe((response) => {
          if (response.succeeded) {
            this.getAll();
            this.hideForm();
          } else {
            console.log('error');
          }
        });
    } else {
      this.http
        .post<Response>(
          environment.baseApiUrl + this.controllerName + environment.create,
          this.selected
        )
        .subscribe((response) => {
          if (response.succeeded) {
            this.getAll();
            this.hideForm();
          } else {
            console.log('error');
          }
        });
    }
  }
  public deleteCategory(id: any): void{
    this.http
      .delete<Response>(
        environment.baseApiUrl + this.controllerName + environment.delete + id
      )
      .subscribe((response) => {
        this.getAll();
      });
  }
  //#endregion

  //#region  form operations
  public createForm(): void {
    const { id, name, minimumStockQuantity } = this.selected;
    this.form = new FormGroup({
      id: new FormControl(id ?? null),
      name: new FormControl(name ?? null, [Validators.minLength(1),  Validators.required]),
      minimumStockQuantity: new FormControl(minimumStockQuantity ?? 0, [
        Validators.required,
        Validators.min(0),
      ]),
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
