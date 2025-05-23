import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {Location} from '@angular/common';


interface BookClub {
  bookClubId: number;
  bookClubTitle: string;
}

@Component({
  templateUrl: './edit-book-club-component.html',
  styleUrl: './edit-book-club-component.css'
})
export class EditBookClubComponent implements OnInit {
  public bookClubId: number = 0;
  public hideComponent: boolean = false;

  constructor(private route: ActivatedRoute,
     private router: Router,
    private location:Location) {
  }

  ngOnInit(): void {
    this.hideComponent = false;
    var paramField = this.route.snapshot.paramMap.get('bookClubId');
    let paramVal = paramField ? Number(paramField) : null;
    if (paramVal !== null) {
      this.bookClubId = paramVal;
    }
  }

  back() { 
    this.hideComponent = true;
    this.location.replaceState('');
    window.location.reload();
  }
}
