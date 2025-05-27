import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EditBookClubComponent } from './edit-book-club-component';
import { BookClubComponent } from './book-club-component';
import { AddBookClubComponent } from './add-book-club-component';
import { ViewBookClubComponent } from './view-book-club-component';

const routes: Routes = [
  { path: 'book-club', component: BookClubComponent},
  { path: 'edit-book-club/:bookClubId', component: EditBookClubComponent },
  { path: 'add-book-club', component: AddBookClubComponent },
  { path: 'view-book-club/:bookClubId', component: ViewBookClubComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
