/**
 * Root Layout Component
 * 
 * Defines the main layout structure for the UMECA Bulletin Board application.
 * Includes:
 * - Header with logo, title, and real-time clock/date
 * - Gradient background
 * - Font configuration (Geist Sans & Geist Mono)
 * 
 * @layout
 */

import type { Metadata } from "next";
import { Geist, Geist_Mono } from "next/font/google";
import "./globals.css";
import TimeClock from "./_components/timeclock";
import CurrentDateInfo from "./_components/currentDate";
import Image from "next/image";

// Configure Geist Sans font
const geistSans = Geist({
  variable: "--font-geist-sans",
  subsets: ["latin"],
});

// Configure Geist Mono font
const geistMono = Geist_Mono({
  variable: "--font-geist-mono",
  subsets: ["latin"],
});

// Page metadata
export const metadata: Metadata = {
  title: "UMECA Bulletin Board",
  description: "CpE 223/L Group Project - Digital bulletin board system for announcements",
};

export default async function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en" className="bg-[linear-gradient(115deg,_#ff512f,_#dd2476)] bg-no-repeat h-screen overflow-hidden">
      <body
        className={`${geistSans.variable} ${geistMono.variable} antialiased h-screen overflow-hidden flex flex-col`}
      >
        <header className="flex items-center justify-between px-6 py-4 flex-shrink-0">
          {/* Logo Section - Left, Bigger and Centered Vertically */}
          <div className="flex items-center">
            <Image 
              src="/logo.png" 
              alt="UMECA Logo" 
              width={400} 
              height={400}
              className="object-contain"
            />
          </div>
          
          {/* Text Content - Right, Center Aligned */}
          <div className="flex flex-col items-center gap-2">
            {/* Title and Description */}
            <div className="flex items-center gap-3">
              <h1 className="text-3xl font-bold text-white drop-shadow-lg">
                UMECA BULLETIN BOARD
              </h1>
              <span className="text-white text-2xl font-light drop-shadow-lg">|</span>
              <p className="text-base text-white font-medium drop-shadow-lg">
                a CpE 223/L Group Project
              </p>
            </div>
            
            {/* Time and Date Section */}
            <div className="flex items-center gap-4">
              <div className="text-sm text-white drop-shadow-lg">
                <TimeClock />
              </div>
              <div className="text-sm text-white drop-shadow-lg">
                <CurrentDateInfo />
              </div>
            </div>
          </div>
        </header>
        <main className="flex-1 overflow-hidden">
          {children}
        </main>
      </body>
    </html>
  );
}
