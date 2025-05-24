import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { FormBuilder } from '@angular/forms';


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
    this.http.put('/bookclub', this.editBookClubForm.value).subscribe(
      (result) => {
        alert('success');
        this.back();
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
