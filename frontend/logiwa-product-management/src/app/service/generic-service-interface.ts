import { Observable } from "rxjs";
import { Response } from "../models/response.model";

export interface GenericServiceInterface<T, TKey> {
    create(t: T): Observable<Response>;
    update(id: TKey, t: T): Observable<Response>;
    get(id: TKey): Observable<Response>;
    getAll(): Observable<Response>;
    delete(id: TKey): Observable<any>;
  }
  