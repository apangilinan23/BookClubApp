import { HttpClient } from '@angular/common/http';
import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';


interface BookClub {
  bookClubId: number;
  bookClubTitle: string;
}

@Component({
  selector: 'book-club',
  templateUrl: './book-club-component.html',
  styleUrl: './book-club-component.css'
})
export class BookClubComponent implements OnInit {
  public bookClubs: BookClub[] = [];
  constructor(private http: HttpClient, private router: Router) { }

  @Output() onEdit = new EventEmitter<boolean>();

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

  viewBookClub(bookClubId: number) {
    this.router.navigate(['edit-book-club', bookClubId])
      .catch((err) => {
        console.log(err)
      }).then(() => {
        this.onEdit.emit(true)
        // window.location.reload();        
      });
  }
}

interface BookClub {
  bookClubId: number;
  bookClubTitle: string;
}