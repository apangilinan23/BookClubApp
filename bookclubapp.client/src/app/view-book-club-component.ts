import { HttpClient } from '@angular/common/http';
import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from '../environments/environment';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';


interface BookClubMember {
  memberId: number;
  name: string;
  booksRead: number;
  booksOnHand: number;//todo: implement in server
}

interface BookClub {
  bookClubId: number;
  bookClubTitle: string;
}

interface BooksReadByMember {
  books: string[],
  name: string;
}

@Component({
  templateUrl: './view-book-club-component.html',
  styleUrl: './view-book-club-component.css'
})
export class ViewBookClubComponent implements OnInit {
  public bookClubId: number = 0;
  public bookClubMembers: BookClubMember[] = [];
  public bookClub: BookClub = { bookClubId: 0, bookClubTitle: '' };
  public booksReadByMember: BooksReadByMember = { books: [], name: '' };
  public showBooksReadPanel: boolean = false;
  
  constructor(private http: HttpClient,
    private router: Router,
    private route: ActivatedRoute,
    private location: Location) { }


  ngOnInit() {
    var paramField = this.route.snapshot.paramMap.get('bookClubId');
    let paramVal = paramField ? Number(paramField) : null;

    if (paramVal !== null) {
      this.bookClubId = paramVal;
      this.getBookClubMembersByBookClubId(this.bookClubId);
    }
  }

  getBookClubMembersByBookClubId(clubId: number) {
    this.http.get<BookClubMember[]>(`/bookclubmember/${clubId}`).subscribe(
      (result) => {
        this.bookClubMembers = result;
      },
      (error) => {
        console.error(error);
      }
    );
    let endPoint = '/bookclub/' + this.bookClubId
    this.http.get<BookClub>(endPoint).subscribe(
      (result) => {
        this.bookClub = result;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  getBooksByMember(memberId: number) {
    this.http.get<BooksReadByMember>(`/bookclubmember/GetBooksByMember/${memberId}`).subscribe(
      (result) => {
        this.booksReadByMember = result;
        this.showBooksReadPanel = true;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  back() {
    this.location.replaceState('');
    window.location.reload();
  }
}
