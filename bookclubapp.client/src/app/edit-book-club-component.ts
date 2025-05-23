import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, ReactiveFormsModule  } from '@angular/forms';
import { BookClubComponent } from './book-club-component';


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
  public bookClub: BookClub = { bookClubId: 0, bookClubTitle: '' };
  editBookClubForm = this.formBuilder.group({
    bookClubId: 0,
    bookClubTitle: ''
  });

  constructor(private route: ActivatedRoute,
    private location: Location,
    private http: HttpClient,
    private formBuilder: FormBuilder) {
  }

  onSubmit(): void {    
    console.log(this.editBookClubForm.value.bookClubId);
    console.log(this.editBookClubForm.value.bookClubTitle);
    
    

    this.http.put('/bookclub', this.editBookClubForm.value).subscribe(
      (result) => {
        alert('success');
      }, (error => {
        alert('error');
      }));
  }

  ngOnInit(): void {
    this.hideComponent = false;
    
    var paramField = this.route.snapshot.paramMap.get('bookClubId');
    let paramVal = paramField ? Number(paramField) : null;
    if (paramVal !== null) {
      this.bookClubId = paramVal;

      let endPoint = '/bookclub/' + this.bookClubId
      this.http.get<BookClub>(endPoint).subscribe(
        (result) => {
          this.bookClub = result;
          this.editBookClubForm.patchValue({bookClubId: this.bookClub.bookClubId, bookClubTitle: this.bookClub.bookClubTitle})
        },
        (error) => {
          console.log(error);
        }
      );
    }
  }

  back() {
    this.hideComponent = true;
    this.location.replaceState('');
    window.location.reload();
  }
}
