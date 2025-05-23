import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EditBookClubComponent } from './edit-book-club-component';
import { BookClubComponent } from './book-club-component';
import { AppComponent } from './app.component';

const routes: Routes = [
  { path: 'book-club', component: BookClubComponent},
  { path: 'edit-book-club/:bookClubId', component: EditBookClubComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
