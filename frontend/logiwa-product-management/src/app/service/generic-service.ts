import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { GenericServiceInterface } from './generic-service-interface';
import { environment } from 'src/environments/environment';
import { Response } from '../models/response.model';

export abstract class GenericService<T, TKey>
  implements GenericServiceInterface<T, TKey>
{
  constructor(protected _http: HttpClient, protected _base: string) {}

  create(t: T): Observable<Response> {
    return this._http.post<Response>(this._base + environment.create, t);
  }

  update(id: TKey, t: T): Observable<Response> {
    return this._http.put<Response>(
      this._base + environment.update + id,
      t,
      {}
    );
  }

  get(id: TKey): Observable<Response> {
    return this._http.get<Response>(this._base + environment.get + id);
  }

  getAll(): Observable<Response> {
    return this._http.get<Response>(this._base + environment.getAll);
  }

  delete(id: TKey): Observable<Response> {
    return this._http.delete<Response>(this._base + environment.delete + id);
  }
}
