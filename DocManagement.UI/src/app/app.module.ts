import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgSelectModule } from '@ng-select/ng-select';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DocumentComponent } from './features/document/document.component';
import { KeywordComponent } from './features/keyword/keyword.component';
import { MappingModalComponent } from './features/mapping/mapping-modal/mapping-modal.component';
import { MappingComponent } from './features/mapping/mapping.component';
import { mapping } from './models/mapping';
import { ConfirmationComponent } from './shared/confirmation/confirmation.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    KeywordComponent,
    MappingComponent,
    DocumentComponent,
    MappingModalComponent,
    ConfirmationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    NgSelectModule,
    NgSelectModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
