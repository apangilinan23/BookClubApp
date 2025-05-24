import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { BookClubComponent } from './book-club-component';


interface BookClub {
  bookClubId: number;
  bookClubTitle: string;
}

@Component({
  templateUrl: './add-book-club-component.html',
  styleUrl: './add-book-club-component.css'
})
export class AddBookClubComponent implements OnInit {
  public bookClubId: number = 0;
  public hideComponent: boolean = false;
  public bookClub: BookClub = { bookClubId: 0, bookClubTitle: '' };
  addBookClubForm = this.formBuilder.group({
    bookClubTitle: ''
  });

  constructor(private route: ActivatedRoute,
    private location: Location,
    private http: HttpClient,
    private formBuilder: FormBuilder) {
  }

  onSubmit(): void {
    if (this.addBookClubForm.value.bookClubTitle?.length === 0) {
      alert('Invalid title. Please enter a valid title');
      return;
    }
    else {
      this.http.post('/bookclub', this.addBookClubForm.value).subscribe(
        (result) => {
          alert('success');
          this.back();
        }, (error => {
          alert('error');
        }));
    }

  }

  ngOnInit(): void {
    this.hideComponent = false;
  }

  back() {
    this.hideComponent = true;
    this.location.replaceState('');
    window.location.reload();
  }
}
