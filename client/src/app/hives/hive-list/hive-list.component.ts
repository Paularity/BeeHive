import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { HiveService, Hive } from '../hive.service';

@Component({
  selector: 'app-hive-list',
  templateUrl: './hive-list.component.html',
})
export class HiveListComponent implements OnInit {
  hives: Hive[] = [];
  statusFilter = new FormControl('all');
  statuses = ['all', 'critical', 'fair', 'good'];

  constructor(private hiveService: HiveService) {}

  ngOnInit(): void {
    this.loadHives();
  }

  loadHives(): void {
    this.hiveService
      .getHives(this.statusFilter.value ?? undefined)
      .subscribe((h: Hive[]) => (this.hives = h));
  }
}
