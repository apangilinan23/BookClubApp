import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BookClubComponent } from './book-club-component';
import { CommonModule } from '@angular/common';
import { EditBookClubComponent } from './edit-book-club-component';
import { ReactiveFormsModule } from '@angular/forms';
import { AddBookClubComponent } from './add-book-club-component';

@NgModule({
  declarations: [
    AppComponent,
    BookClubComponent,
    EditBookClubComponent,
    AddBookClubComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, CommonModule, ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }