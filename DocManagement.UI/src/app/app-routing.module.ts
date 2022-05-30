import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DocumentComponent } from './features/document/document.component';
import { KeywordComponent } from './features/keyword/keyword.component';
import { MappingComponent } from './features/mapping/mapping.component';

const routes: Routes = [

  { path: 'Mapping', component: MappingComponent },
  { path: 'Keyword', component: KeywordComponent },
  { path: 'Document', component: DocumentComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {



}
