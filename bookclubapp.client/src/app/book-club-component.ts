import { HttpClient } from '@angular/common/http';
import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from './../environments/environment';
import { ActivatedRoute } from '@angular/router';


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
  apiUrl: string = `${environment.apiUrl}`;
  public bookClubs: BookClub[] = [];
  constructor(private http: HttpClient,
    private router: Router,
    private route: ActivatedRoute) { }

  @Output() onEdit = new EventEmitter<boolean>();
  @Output() onAdd = new EventEmitter<boolean>();

  ngOnInit() {
    this.getBookClubs();
  }

  getBookClubs() {
    this.http.get<BookClub[]>('/bookclub').subscribe(
      (result) => {
        this.bookClubs = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  editBookClub(bookClubId: number) {
    this.router.navigate(['edit-book-club', bookClubId])
      .catch((err) => {
        console.log(err)
      }).then(() => {
        this.onEdit.emit(true)
      });
  }

  viewBookClub(bookClubId: number) {
    this.router.navigate(['view-book-club', bookClubId])
      .catch((err) => {
        console.log(err)
      }).then(() => {
        this.onEdit.emit(true)
      });
  }

  deleteBookClub(bookClubId: number) {
    if (confirm("Are you sure you want to delete this club?")) {
      if (bookClubId !== 0) {
        let endPoint = '/bookclub/' + bookClubId
        this.http.delete(endPoint).subscribe(
          (result) => {
            if (result !== true) {
              alert('Cannot delete this club. Active club members found');
            }
            else {
              window.location.reload();
            }

          },
          (error) => {
            console.log(error);
          }
        );
      }
    } else {
      return;
    }
  }

  addNewClub() {
    this.router.navigate(['add-book-club'])
      .catch((err) => {
        console.log(err)
      }).then(() => {
        this.onAdd.emit(true)
      });
  }
}

interface BookClub {
  bookClubId: number;
  bookClubTitle: string;
}