import { Component, OnInit } from '@angular/core';
import { mapping } from 'src/app/models/mapping';
import { MappingService } from 'src/app/services/mapping.service';
import { NgbModal, NgbModalOptions, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { MappingModalComponent } from './mapping-modal/mapping-modal.component';
import { ConfirmationComponent } from 'src/app/shared/confirmation/confirmation.component';
import { ToastrService } from 'ngx-toastr';
import { keyword } from 'src/app/models/keyword';
import { FormGroup } from '@angular/forms';
import { keywordService } from 'src/app/services/keyword.service';
@Component({
  selector: 'app-mapping',
  templateUrl: './mapping.component.html',
  styleUrls: ['./mapping.component.css']
})
export class MappingComponent implements OnInit {
  mappings: mapping[] = [];
  keywords: keyword[] = [];
  mappingForm: FormGroup = new FormGroup({});
  errorMessage: any;
  constructor(private srvMapping: MappingService, private modalService: NgbModal, private toastr: ToastrService, private srvKeyword: keywordService) { }
  createNewKeyword(name: any) { }
  ngOnInit() {
    this.getMappings();
    this.getKeywords();
    this.createNewKeyword = (name: any) => {



      this.srvKeyword.addkeyword(name).subscribe(
        (data) => { this.keywords = data },
        (err) => { this.errorMessage = <any>err }

      )




    }
  }
  getMappings() {
    this.srvMapping.getAllMappings().subscribe(

      {
        next: (res) => { this.mappings = res; },
        error: (e) => { this.errorMessage = <any>e }
      }

    )

  }

  getKeywords() {
    this.srvKeyword.getAllkeywords().subscribe((res) => {
      this.keywords = res;

    })
  }





  filterList(item: keyword) {
    if (item != undefined) {
      this.srvMapping.getMappingsByKeyword(item.id).subscribe(

        {
          next: (res) => { this.mappings = res; },
          error: (e) => { this.errorMessage = <any>e }
        }

      )


    }
    else {
      this.getMappings();
    }


  }
  showSuccess() {
    this.toastr.success('Updated Successfully!', 'Update!');
  }
  showError(message: string) {
    this.toastr.error(message, 'Error!');
  }
  edit(mapping: mapping) {

    let _modalRef: NgbModalRef;
    _modalRef = this.modalService.open(MappingModalComponent, { size: 'xl' });
    _modalRef.componentInstance._ItemForEdit = mapping;
    //  _modalRef.componentInstance.country = this.country;
    //ChildAllowance Emitter to save the values (the save function is on parent)
    _modalRef.componentInstance._eventEmitterModalValues.subscribe((_list: mapping) => {


      this.update_Item(_list);



    });
  }
  confirmDelete(item: mapping) {
    let _modalRef: NgbModalRef;
    const index = this.mappings.indexOf(item);
    _modalRef = this.modalService.open(ConfirmationComponent, { size: 'lg', backdrop: 'static' });



    _modalRef.componentInstance.childConfirm.subscribe((IsConfirm: boolean) => {
      if (IsConfirm) {
        if (index > -1) {
          this.mappings.splice(index, 1);

          this.delete_Item(item.mappingID);
        }
      }
    })

  }
  modalConfiguration(size?: any) {
    let modalOption: NgbModalOptions = {};
    modalOption.backdrop = 'static';
    modalOption.keyboard = false;
    modalOption.windowClass = 'modal-holder';
    modalOption.centered = true;
    modalOption.size = size === undefined ? 'lg' : size;
    return modalOption;
  }

  delete_Item(id: number) {
    return this.srvMapping.deleteMapping(id).subscribe(
      (res) => {

      },

      (err) => { this.errorMessage = <any>err }

    )
  }

  update_Item(item: mapping) {


    this.srvMapping.updateMapping(item).subscribe(

      data => {
        this.mappings = data

        this.showSuccess();
      },
      (err) => { this.errorMessage = <any>err }
    )
  }


  openModal() {

    let _modalRef: NgbModalRef;

    _modalRef = this.modalService.open(MappingModalComponent, { size: 'xl' });


    _modalRef.componentInstance._eventEmitterModalValues.subscribe((_list: mapping) => {

      // if (_list.add_or_update == 'add') {

      this.add_Item(_list)
      //  }
      // else {
      //   this.update_Item(_list)
      // }





    });
  }


  add_Item(item: mapping) {

    const _isExisted = this.CheckIfExist(item)
    if (!_isExisted) {
      // this.mappings.push(item);

      this.srvMapping.addMapping(item).subscribe(
        {
          next: (res) => { this.mappings = res },
          error: (e) => { this.errorMessage = <any>e }
        }
      )

    }
    else {


      this.showError('already exists');
    }

  }
  CheckIfExist(item: mapping): boolean {
    let _IsExist: boolean = false;
    for (let index = 0; index < this.mappings.length; index++) {
      const element = this.mappings[index];
      if (item.documentID == element.documentID && item.keywordID == element.keywordID) {
        _IsExist = true;
        break;
      }
    }
    return _IsExist;
  }
}
