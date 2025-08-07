import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-confirmation-dialog',
  standalone: false,
  templateUrl: './confirmation-dialog.component.html',
  styleUrl: './confirmation-dialog.component.css'
})
export class ConfirmationDialogComponent implements OnInit {
  @Input() message: string = 'Are you sure?';
  @Input() title: string = 'Confirm';
  @Input() okButtonText: string = 'Ok';
  @Input() cancelButtonText: string = 'Cancel';

  constructor(public activeModal: NgbActiveModal) {}

  ngOnInit(): void {}

  public decline(): void {
    this.activeModal.dismiss(false);
  }
  public accept(): void {
    this.activeModal.close(true);
  }
  public close(): void {
    this.activeModal.dismiss(false);
  }
}
