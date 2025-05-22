import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

interface BookClub {
  bookClubId : number;
  bookClubTitle : string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];
  public bookClubs: BookClub[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getBookCLubs();
  }

  getBookCLubs() {
    this.http.get<BookClub[]>('/bookclub').subscribe(
      (result) => {
        this.bookClubs = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'bookclubapp.client';
}
