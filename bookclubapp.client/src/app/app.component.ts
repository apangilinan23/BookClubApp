import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd, Event } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  public hideComponent: boolean = false;

    constructor(private router: Router) { }
  
  
  ngOnInit(): void {
    this.hideComponent = false;

    this.router.events.subscribe((event: Event) => {
      if (event instanceof NavigationEnd) {
        if (event.url !== '/') {
          this.hideComponent = true;
        } 
      }
    });
  }

  onEditBookClub(willHide: boolean){
    this.hideComponent = willHide;
  }

  onAddBookClub(willHide: boolean){
    this.hideComponent = willHide;
  }

  title = 'Book club app';
}
