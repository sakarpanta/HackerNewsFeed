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

  private APIBaseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getNewsItemsForCategory(category: string): Observable<NewsItem[]> {
    return this.http.get<NewsItem[]>(`${this.APIBaseUrl}/news/${category}`)
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
