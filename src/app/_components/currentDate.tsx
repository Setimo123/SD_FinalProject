/**
 * CurrentDateInfo Component
 * 
 * Displays the current date in a readable format.
 * Updates every second to ensure accuracy.
 * 
 * Format: "Weekday, Month Day, Year"
 * Example: "Monday, November 03, 2025"
 * 
 * Features:
 * - Client-side only rendering to avoid hydration mismatch
 * - Auto-updates every second
 * - Monospace font for consistent display
 * 
 * @component
 */

'use client';

import { useEffect, useState } from 'react';
import dayjs from 'dayjs';

/**
 * Current date display component
 * @returns Formatted date (Weekday, Month DD, YYYY)
 */
export default function CurrentDateInfo() {
  const [now, setNow] = useState<dayjs.Dayjs | null>(null);
  const [mounted, setMounted] = useState(false);

  useEffect(() => {
    // Set mounted to avoid hydration mismatch
    setMounted(true);
    setNow(dayjs());
    
    // Update date every second (in case of day change)
    const interval = setInterval(() => {
      setNow(dayjs());
    }, 1000);
    
    // Cleanup interval on unmount
    return () => clearInterval(interval);
  }, []);

  // Show loading placeholder until mounted
  if (!mounted || !now) {
    return (
      <div className="text-white space-y-1 font-mono text-2xl">
        <p>Loading...</p>
      </div>
    );
  }

  // Extract date components
  const month = now.format('MMMM');    // Full month name (e.g., November)
  const day = now.format('DD');        // Day with leading zero (e.g., 03)
  const year = now.format('YYYY');     // Full year (e.g., 2025)
  const weekday = now.format('dddd');  // Full weekday name (e.g., Monday)

  return (
    <div className="text-white space-y-1 font-mono text-2xl">
      <p>{weekday}, {month} {day}, {year}</p>
    </div>
  );
}
