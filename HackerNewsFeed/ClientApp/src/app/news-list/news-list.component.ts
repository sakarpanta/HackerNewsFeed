import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { NewsService } from '../news.service';
import { NewsItem } from '../newsitem';


@Component({
  selector: 'app-news-list',
  templateUrl: './news-list.component.html',
  styleUrls: ['./news-list.component.css'],
  providers: [ NewsService ]
})
export class NewsListComponent implements OnInit {

  newsItems: Int32Array[];
  category: string;

  constructor(
    private route: ActivatedRoute,
    private newsService: NewsService
  ) { }

  ngOnInit() {
    let category = this.route.snapshot.paramMap.get('category');
    this.category = category;
    this.getAllNewsItems();
  }

  getAllNewsItems(): void {
    this.newsService.getNewsItemIdsForCategory(this.category)
      .subscribe(newsItems => this.newsItems = newsItems);
  }

}
