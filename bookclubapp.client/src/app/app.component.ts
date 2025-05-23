import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  public hideComponent: boolean = false;
  ngOnInit(): void {
    this.hideComponent = false;
  }


  onEditBookClub(willHide: boolean){
    this.hideComponent = willHide;
  }
  title = 'Book club app';
}
