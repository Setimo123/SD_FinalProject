'use client';

/**
 * Bulletin Carousel Component
 * 
 * Displays bulletins in a vertical auto-scrolling carousel with an overview card.
 * Features:
 * - Auto-plays with 5-second intervals
 * - Vertical scrolling orientation
 * - Overview card showing all bulletins
 * - Individual cards for each bulletin with title, content, and timestamp
 * 
 * @component
 */

import Autoplay from "embla-carousel-autoplay";
import * as React from "react";
import type { UseEmblaCarouselType } from "embla-carousel-react";

import {
  Carousel,
  CarouselContent,
  CarouselItem,
} from "@/components/ui/carousel";

type CarouselApi = UseEmblaCarouselType[1];

/**
 * Props for the CarouselOrientation component
 */
interface CarouselOrientationProps {
  bulletinData: {
    /** Unique identifier */
    Id: number;
    /** Bulletin title */
    Title: string;
    /** Bulletin content/body */
    Content: string;
    /** Publication date and time */
    DatePublished: string;
    /** Status code (1 = active) */
    Status: number;
  }[];
}

/**
 * Bulletin carousel component with auto-play functionality
 */
export default function CarouselOrientation({ bulletinData }: CarouselOrientationProps) {
  const [api, setApi] = React.useState<CarouselApi>();

  // Configure autoplay plugin
  const autoplayPlugin = React.useRef(
    Autoplay({ 
      delay: 5000, // 5 seconds between slides
      stopOnInteraction: false, 
      stopOnMouseEnter: false,
      stopOnLastSnap: false
    })
  );

  // Initialize autoplay when carousel API is ready
  React.useEffect(() => {
    if (!api) {
      return;
    }

    // Force start autoplay
    autoplayPlugin.current.play();
    
    console.log('✅ Carousel autoplay started - should auto-scroll every 5 seconds');
  }, [api]);


  return (
    <div className="w-full h-full flex items-center justify-center">
      <Carousel
        opts={{
          align: "start",
          loop: true,
          watchDrag: true
        }}
        plugins={[autoplayPlugin.current]}
        orientation="vertical"
        className="w-full max-h-full"
        setApi={setApi}
      >
        <CarouselContent className="h-[calc(100vh-300px)]">
          {/* Overview Card */}
          <CarouselItem className="basis-full">
            <div
              className="flex flex-col w-[96%] h-full px-6 py-8 mx-auto border-1 border-t-4 border-gray-500/40 border-t-[#dc3938] rounded-xl backdrop-blur-2xl shadow-2xl overflow-visible"
            >
              <div className="font-bold text-7xl text-white mb-6 flex-shrink-0 leading-[1.2] pb-3 drop-shadow-lg">
                Bulletin Overview
              </div>
              <div className="text-white text-2xl flex-1 overflow-y-auto drop-shadow-md">
                <p className="mb-4 text-3xl font-bold drop-shadow-lg">Total Bulletins: {bulletinData?.length || 0}</p>
                <div className="space-y-3">
                  {bulletinData?.length > 0 && bulletinData.map((item, index) => (
                    <div key={index} className="border-l-4 border-white/50 pl-4 py-2 bg-black/20 rounded-r">
                      <div className="font-bold text-3xl mb-1 text-white drop-shadow-lg">{item.Title}</div>
                      <div className="text-xl text-white font-medium drop-shadow-md">
                        Published: {new Date(item.DatePublished).toLocaleDateString('en-US', { 
                          month: 'short', 
                          day: 'numeric', 
                          year: 'numeric',
                          hour: '2-digit', 
                          minute: '2-digit'
                        })}
                      </div>
                    </div>
                  ))}
                </div>
              </div>
            </div>
          </CarouselItem>
          
          {/* Individual Bulletin Cards */}
          {bulletinData?.length>0 &&bulletinData.map((item, index) => (
            <CarouselItem key={index} className="basis-full">
                  <div
                    className="flex flex-col w-[96%] h-full px-6 py-8 mx-auto border-1 border-t-4 border-gray-500/40 border-t-[#dc3938] rounded-xl backdrop-blur-2xl shadow-2xl overflow-visible"
                  >
                    <div className="flex items-start justify-between mb-4 flex-shrink-0">
                      <div className="font-bold text-7xl text-white line-clamp-2 leading-[1.2] pb-3 flex-1 drop-shadow-lg">{item.Title}</div>
                      <div className="text-white text-lg font-medium ml-4 mt-2 whitespace-nowrap drop-shadow-lg">
                        {new Date(item.DatePublished).toLocaleDateString('en-US', { 
                          month: 'short', 
                          day: 'numeric', 
                          year: 'numeric' 
                        })}
                        <br />
                        {new Date(item.DatePublished).toLocaleTimeString('en-US', { 
                          hour: '2-digit', 
                          minute: '2-digit',
                          hour12: true 
                        })}
                      </div>
                    </div>
                    <div className="text-gray-200 text-2xl flex-1 overflow-hidden line-clamp-[10] drop-shadow-md">
                      {item.Content}
                    </div>
                  </div>
            </CarouselItem>
          ))}
        </CarouselContent>
      </Carousel>
    </div>
  )
}