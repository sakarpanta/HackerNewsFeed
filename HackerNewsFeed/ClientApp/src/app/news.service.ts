import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NewsItem } from './newsitem';
import { environment } from '../environments/environment';
import { Observable } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { of } from 'rxjs/observable/of';



const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class NewsService {

  private API_BASE_URL = environment.API_BASE_URL;

  constructor(private http: HttpClient) { }

  getNewsItemsForIds(ids: Number[]): Observable<NewsItem[]> {
    let idString = JSON.stringify(ids);
    return this.http.get<NewsItem[]>(`${this.API_BASE_URL}/news/${idString}`)
      .pipe(
        catchError(this.handleError('getNewsItems', []))
      );
  }

  getNewsItemIdsForCategory(category: string): Observable<Number[]> {
    return this.http.get<Number[]>(`${this.API_BASE_URL}/news/${category}`)
      .pipe(
        catchError(this.handleError('getNewsItems', []))
      );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  }

}
