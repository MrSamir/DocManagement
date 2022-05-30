import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { document } from 'src/app/models/document';
import { keyword } from 'src/app/models/keyword';
import { mapping } from 'src/app/models/mapping';
import { documentService } from 'src/app/services/document.service';
import { keywordService } from 'src/app/services/keyword.service';

@Component({
  selector: 'app-mapping-modal',
  templateUrl: './mapping-modal.component.html',
  styleUrls: ['./mapping-modal.component.css']
})
export class MappingModalComponent implements OnInit {
  mappingForm: FormGroup = new FormGroup({});
  keywords: keyword[] = [];
  documents: document[] = [];
  _submit: boolean = false;

  errorMessage: any;

  @Output() _eventEmitterModalValues: EventEmitter<any> = new EventEmitter();
  @Input() _ItemForEdit: mapping = new mapping();

  constructor(private fb: FormBuilder, private activeModal: NgbActiveModal, private srvDocument: documentService, private srvKeyword: keywordService) { }
  createNewKeyword(name: any) { }
  ngOnInit() {
    this.iniForm();
    if (this._ItemForEdit !== null && this._ItemForEdit !== undefined && this._ItemForEdit.mappingID != 0) {
      this.setFormValuesForEdit(this._ItemForEdit)

    }


    this.createNewKeyword = (name: any) => {



      this.srvKeyword.addkeyword(name).subscribe(
        (data) => { this.keywords = data },
        (err) => { this.errorMessage = <any>err }

      )




    }

  }
  iniForm() {
    this.mappingForm = this.fb.group({
      mappingID: [0],
      documentID: [, Validators.required],
      keywordID: [, Validators.required],


    });
    this.getDocuments();
    this.getKeywords();
  }
  setFormValuesForEdit(item: mapping) {


    this.mappingForm.patchValue(item); //path value can exclude some controls

  }


  close() {
    this.activeModal.close();
  }

  get form() {
    return this.mappingForm.controls;

  }

  getKeywords() {
    this.srvKeyword.getAllkeywords().subscribe((res) => {
      this.keywords = res;

    })
  }

  getDocuments() {
    this.srvDocument.getAlldocuments().subscribe((res) => {
      this.documents = res;

    })
  }
  save() {
    //This submit flag is used in validation

    this._submit = true;
    if (this.mappingForm.valid) {
      let x: mapping = new mapping()
      x = this.mappingForm.value;



      //Emit FormValues to the parent (Output)
      this._eventEmitterModalValues.emit(x);
      //Reset submit flag after successful saving
      this._submit = false;
      this.close();
    }
  }
}
