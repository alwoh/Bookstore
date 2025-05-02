import { Injectable } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmationDialogComponent } from '../confirmation-dialog/confirmation-dialog.component';

@Injectable({
    providedIn: 'root',
})
export class ConfirmationDialogService {
    constructor(private modalService: NgbModal) {}

    confirm(message: string, title: string = 'Confirm', otherOptions: any = {}): Promise<boolean> {
        const modalRef = this.modalService.open(ConfirmationDialogComponent, { size: 'lg', centered: true, ...otherOptions });
        modalRef.componentInstance.message = message;
        modalRef.componentInstance.title = title;
        modalRef.componentInstance.okButtonText = 'Ok';
        modalRef.componentInstance.cancelButtonText = 'Cancel';

        return modalRef.result;
    }
}
