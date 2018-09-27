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

  allItemIds = [];
  newsItems = [];
  category: string;
  currentIndex = 0;
  page_size = 10;
  title: string;

  constructor(
    private route: ActivatedRoute,
    private newsService: NewsService,
    private router: Router
  ) {
    this.router.routeReuseStrategy.shouldReuseRoute = function () {
      return false;
    };
  }

  ngOnInit() {
    let category = this.route.snapshot.paramMap.get('category');
    this.category = category;
    this.title = (category == "new" ? "Most Recent" : category);
    this.getAllNewsItemIds();
  }

  getAllNewsItemIds(): void {
    this.newsService.getNewsItemIdsForCategory(this.category)
      .subscribe(
        newsIds => this.loadNewsItems(newsIds)
      );
  }

  loadNewsItems(newsIds: Number[]) {
    this.allItemIds = newsIds;
    this.getItems();
  }

  onScroll(): void {
    this.getItems();
  }

  getItems(): void {
    let arr = this.allItemIds.slice(this.currentIndex, this.currentIndex + this.page_size);
    this.newsService.getNewsItemsForIds(arr)
      .subscribe(
        newsItems => this.onSuccess(newsItems)
      );
  }

  onSuccess(newsItems: NewsItem[]): void {
    newsItems.forEach(item => this.newsItems.push(item));
    this.currentIndex = this.currentIndex + this.page_size + 1;
  }

}
