import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { NewsService } from '../news.service';
import { NewsItem } from '../newsitem';


@Component({
  selector: 'app-news-list',
  templateUrl: './news-list.component.html',
  styleUrls: ['./news-list.component.css']
})
export class NewsListComponent implements OnInit {

  newsItems: NewsItem[];

  constructor(
    private route: ActivatedRoute,
    private newsService: NewsService
  ) { }

  ngOnInit() {
    let category = this.route.snapshot.paramMap.get('category');
    this.getAllNewsItems(category);
  }

  getAllNewsItems(category: string): void {
    this.newsService.getNewsItems(category)
      .subscribe(newsItems => this.newsItems = newsItems);
  }

}
