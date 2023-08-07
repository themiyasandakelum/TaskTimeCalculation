import { Component, OnInit } from "@angular/core";
import { ApiServiceService } from "src/app/services/api-service.service";

@Component({
  selector: "home",
  templateUrl: "./home.html",
  styleUrls: ["./home.scss"],
})
export class DisplayComponent implements OnInit {
  startingDate: string | null;
  numberOfDates: number;
  endDate: Date;
  minDate: string;

  constructor(private apiService: ApiServiceService) {
    const today = new Date();
    this.minDate = this.formatDate(today);
  }

  formatDate(date: Date): string {
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, "0");
    const day = String(date.getDate()).padStart(2, "0");
    return `${year}-${month}-${day}`;
  }

  updateMinDate(selectedDate: string): void {
    const currentDate = new Date();
    const selected = new Date(selectedDate);
    if (selected < currentDate) {
      this.startingDate = null; // Reset startingDate if a previous date is selected
    }
    this.minDate = this.formatDate(currentDate);
  }

  ngOnInit() {}

  generateEndDate(): void {
    if (!this.startingDate || !this.numberOfDates) {
      alert("Please enter required data.");
      return;
    }

    const startDate = this.reformatDate(this.startingDate);
    this.apiService.getDates(startDate, this.numberOfDates).subscribe(
      (response) => {
        console.log(response.endDate);
        const dateString = response.endDate;
        const parts = dateString.split("/");
        const day = Number(parts[0]);
        const month = Number(parts[1]) - 1; // Subtract 1 because months are zero-based
        const year = Number(parts[2]);

        this.endDate = new Date(year, month, day);
        console.log(this.endDate);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  reformatDate(date: string): string {
    const parts = date.split("-");
    const year = parts[0];
    const month = parts[1];
    const day = parts[2];
    return `${year}/${month}/${day}`;
  }

  getMinDate(): string {
    const today = new Date();
    const year = today.getFullYear();
    const month = String(today.getMonth() + 1).padStart(2, "0");
    const day = String(today.getDate()).padStart(2, "0");
    return `${year}-${month}-${day}`;
  }
}
